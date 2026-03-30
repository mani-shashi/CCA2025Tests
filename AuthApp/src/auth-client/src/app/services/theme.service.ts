import { Injectable, signal, effect } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class ThemeService {
  private readonly THEME_KEY = 'theme';
  private darkMode = signal(this.loadThemePreference());

  readonly isDarkMode = this.darkMode.asReadonly();

  constructor() {
    effect(() => {
      this.applyTheme(this.darkMode());
    });
  }

  private loadThemePreference(): boolean {
    const stored = localStorage.getItem(this.THEME_KEY);
    if (stored !== null) {
      return stored === 'dark';
    }
    return window.matchMedia('(prefers-color-scheme: dark)').matches;
  }

  private applyTheme(isDark: boolean): void {
    document.body.classList.toggle('dark-theme', isDark);
    localStorage.setItem(this.THEME_KEY, isDark ? 'dark' : 'light');
  }

  toggleTheme(): void {
    this.darkMode.update(current => !current);
  }
}
