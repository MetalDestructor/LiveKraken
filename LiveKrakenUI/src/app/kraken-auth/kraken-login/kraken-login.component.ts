import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';
import { DialogLoginData } from './dialog-login-data';

@Component({
  selector: 'app-kraken-login',
  templateUrl: './kraken-login.component.html',
  styleUrls: ['./kraken-login.component.css']
})
export class KrakenLoginComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<KrakenLoginComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogLoginData) {}

  ngOnInit() {
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
