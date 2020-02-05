import { Injectable, OnDestroy } from "@angular/core";
import { MatDialog, MatSnackBar } from "@angular/material";
import { Router } from "@angular/router";
import { AuthService } from "../kraken-auth/auth.service";
import { KrakenLoginComponent } from "../kraken-auth/kraken-login/kraken-login.component";
import { environment } from "src/environments/environment";
import { KrakenRegisterComponent } from "../kraken-auth/kraken-register/kraken-register.component";
import { Subscription } from 'rxjs';

@Injectable({ providedIn: "root" })
export class DialogService implements OnDestroy {
  email: string;
  username: string;
  password: string;
  token: string;
  token_key: string;
  subscription: Subscription;
  constructor(public router: Router) {
    this.token = localStorage.getItem(environment.token_key);
    this.token_key = environment.token_key;
  }

  openLoginDialog(
    dialog: MatDialog,
    authService: AuthService,
    snackBar: MatSnackBar
  ) {
    const dialogRef = dialog.open(KrakenLoginComponent, {
      width: "250px",
      data: { username: this.username, password: this.password }
    });

    this.subscription = dialogRef.afterClosed().subscribe(result => {
      if (result != null) {
        authService.loginUser(result).subscribe(
          res => {
            this.token = res[this.token_key];
            localStorage.setItem(this.token_key, res[this.token_key]);
          },
          err => {
            snackBar.open("An error has occured!", "Close");
          },
          () => {
            snackBar.open("Successfully logged in!", "Close", {
              panelClass: "custom-class-green"
            });
            this.router.navigate(["/"]);
          }
        );
      }
    });
  }

  openRegisterDialog(
    dialog: MatDialog,
    authService: AuthService,
    snackBar: MatSnackBar
  ) {
    const dialogRef = dialog.open(KrakenRegisterComponent, {
      width: "250px",
      data: {
        username: this.username,
        email: this.email,
        password: this.password
      }
    });

    this.subscription = dialogRef.afterClosed().subscribe(result => {
      if (result != null) {
        authService.registerUser(result).subscribe(
          res => {
            this.token = res[this.token_key];
            localStorage.setItem(this.token_key, res[this.token_key]);
          },
          err => {
            snackBar.open("An error has occured!", "Close");
          },
          () => {
            snackBar.open("Successfully registered!", "Close", {
              panelClass: "custom-class-green"
            });
            this.router.navigate(["/browse"]);
          }
        );
      }
    });
  }

  ngOnDestroy(){
      this.subscription.unsubscribe();
  }
}
