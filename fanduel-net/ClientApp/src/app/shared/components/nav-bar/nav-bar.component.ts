import { Component, Inject, OnInit } from '@angular/core';
import { APP_CONFIG, AppConfig } from 'src/app/configs/app.config';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.scss'],
})
export class NavBarComponent implements OnInit {
  appConfig: any;
  menuItems: any[] = [];
  menuItemsDefault: any[] = [];

  addOnBlur = true;

  constructor(@Inject(APP_CONFIG) appConfig: any) {
    this.appConfig = appConfig;
  }

  ngOnInit() {
    this.loadMenus();
  }

  private loadMenus(): void {
    this.menuItems = [
      {
        link: '/',
        name: 'Home',
        icon: 'fas fa-home'
      },
      {
        link: '/' + AppConfig.routes.sports,
        name: 'Sports',
        icon: 'fas fa-football'
      },
      {
        link: '/' + AppConfig.routes.teams,
        name: 'Teams',
        icon: 'fas fa-people-group'
      },
      {
        link: '/' + AppConfig.routes.error404,
        name: 'Not found page',
        icon: 'fas fa-exclamation'
      },
    ];

    this.menuItemsDefault = [
      {
        link: '/',
        name: 'FAQ',
        icon: 'far fa-question-circle'
      },
      {
        link: '/',
        name: 'T&C',
        icon: 'far fa-list-alt'
      },
      {
        link: '/',
        name: 'Privacy policy',
        icon: 'fas fa-user-secret'
      }
    ];
  }
}
