import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FlexLayoutModule } from '@angular/flex-layout';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { NavBarComponent } from 'src/app/shared/components/nav-bar/nav-bar.component';
import { FooterComponent } from 'src/app/shared/components/footer/footer.component';
import { HeadingComponent } from 'src/app/shared/components/heading/heading.component';
import { EmptyComponent } from 'src/app/shared/components/empty/empty.component';
import { CardComponent } from 'src/app/shared/components/card/card.component';
import { SubHeadingComponent } from 'src/app/shared/components/sub-heading/sub-heading.component';

import { MaterialModule } from './material.module';

@NgModule({
  declarations: [
    NavBarComponent,
    FooterComponent,
    HeadingComponent,
    SubHeadingComponent,
    EmptyComponent,
    CardComponent,
  ],
  imports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  exports: [
    CommonModule,
    MaterialModule,
    RouterModule,
    FlexLayoutModule,
    FormsModule,
    ReactiveFormsModule,
    NavBarComponent,
    FooterComponent,
    HeadingComponent,
    SubHeadingComponent,
    EmptyComponent,
    CardComponent,
  ]
})
export class SharedModule {}
