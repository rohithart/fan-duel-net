import { InjectionToken } from '@angular/core';

export const APP_CONFIG = new InjectionToken('app.config');

export const AppConfig = {
  routes: {
    home: 'home',
    sport: 'sport',
    sports: 'sports',
    team: 'team',
    teams: 'teams',
    error404: '404'
  },
};
