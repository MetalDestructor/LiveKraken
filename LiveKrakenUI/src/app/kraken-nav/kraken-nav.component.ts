import { Component, OnInit } from "@angular/core";
import { MatDialog } from "@angular/material";
import { MatSnackBar } from "@angular/material/snack-bar";

import { AuthService } from "../kraken-auth/auth.service";
import { DialogService } from './dialog.service';
import { Router } from '@angular/router';

@Component({
  selector: "app-kraken-nav",
  templateUrl: "./kraken-nav.component.html",
  styleUrls: ["./kraken-nav.component.css"]
})
export class KrakenNavComponent implements OnInit {
  constructor(public dialog: MatDialog, public authService: AuthService, public dialogService: DialogService, private _snackBar: MatSnackBar, private router: Router ) {}

  username: string;
  email: string;
  password: string;

  ngOnInit() {

  }

  getUsername(): string {
    return this.authService.getUserInfo().username;
  }

  openLoginDialog(): void {
    this.dialogService.openLoginDialog(this.dialog, this.authService, this._snackBar);
  }

  openRegisterDialog(): void {
    this.dialogService.openRegisterDialog(this.dialog, this.authService, this._snackBar);
  }
}
