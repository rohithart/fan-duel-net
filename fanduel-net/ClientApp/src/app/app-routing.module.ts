import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AppConfig } from './configs/app.config';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { HomeComponent } from './components/home/home.component';
import { SportsComponent } from './components/sports/sports.component';
import { SportComponent } from './components/sports/sport/sport.component';
import { TeamsComponent } from './components/teams/teams.component';
import { TeamComponent } from './components/teams/team/team.component';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: AppConfig.routes.sports, component: SportsComponent, pathMatch: 'full' },
  { path: `${AppConfig.routes.sport}/:id`, component: SportComponent, pathMatch: 'full' },
  { path: AppConfig.routes.teams, component: TeamsComponent, pathMatch: 'full' },
  { path: `${AppConfig.routes.team}/:id`, component: TeamComponent, pathMatch: 'full' },
  { path: AppConfig.routes.error404, component: NotFoundComponent },
  { path: '**', redirectTo: '/' + AppConfig.routes.error404 }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
