import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { HttpClientModule } from '@angular/common/http';
import { ToastrModule } from 'ngx-toastr';

import { AppRoutingModule } from './app-routing.module';
import { APP_CONFIG, AppConfig } from './configs/app.config';

import { AppComponent } from './app.component';
import { SharedModule } from './shared/modules/shared.module';
import { MaterialModule } from './shared/modules/material.module';
import { HomeModule } from './components/home/home.module';
import { SportsModule } from './components/sports/sports.module';
import { TeamsModule } from './components/teams/teams.module';
import { NotFoundModule } from './components/not-found/not-found.module';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MaterialModule,
    SharedModule,
    NotFoundModule,
    HomeModule,
    SportsModule,
    TeamsModule,
    ToastrModule.forRoot(),
  ],
  providers: [
    { provide: APP_CONFIG, useValue: AppConfig },
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
