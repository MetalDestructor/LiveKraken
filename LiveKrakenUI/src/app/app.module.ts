import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import {
  MatButtonModule,
  MatCardModule,
  MatToolbarModule,
  MatInputModule,
  MatListModule,
  MatDatepickerModule,
  MatNativeDateModule,
  MatIconModule,
  MatGridListModule,
  MatAutocompleteModule,
  MatChipsModule,
  MatDialogModule,
  MAT_DIALOG_DEFAULT_OPTIONS,
  MatSnackBarModule,
  MAT_SNACK_BAR_DEFAULT_OPTIONS
} from '@angular/material';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { KrakenNavComponent } from './kraken-nav/kraken-nav.component';
import { KrakenBrowseComponent } from './kraken-browse/kraken-browse.component';
import { KrakenLoginComponent } from './kraken-auth/kraken-login/kraken-login.component';
import { KrakenRegisterComponent } from './kraken-auth/kraken-register/kraken-register.component';
import { environment } from 'src/environments/environment';
import { KrakenStreamComponent } from './kraken-stream/kraken-stream.component';

export function tokenGetter() {
  return localStorage.getItem(environment.token_key);
}

@NgModule({
  declarations: [
    AppComponent,
    KrakenNavComponent,
    KrakenBrowseComponent,
    KrakenLoginComponent,
    KrakenRegisterComponent,
    KrakenStreamComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatCardModule,
    MatToolbarModule,
    MatInputModule,
    FormsModule,
    MatListModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatIconModule,
    MatGridListModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    MatChipsModule,
    MatDialogModule,
    MatSnackBarModule,
    HttpClientModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter
      }
    })
  ],
  entryComponents: [
    KrakenLoginComponent,
    KrakenRegisterComponent
  ],
  providers: [
    {provide: MAT_DIALOG_DEFAULT_OPTIONS, useValue: {hasBackdrop: true}},
    {provide: MAT_SNACK_BAR_DEFAULT_OPTIONS, useValue: {duration: 2500}}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
