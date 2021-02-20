import {HttpClient} from '@angular/common/http';
import {Component, OnInit} from '@angular/core';
import {MatDialog} from '@angular/material/dialog';
import {Car, CarsClient, CarType} from '../web-api-client';
import {CreateCarDialogComponent} from './create-car-dialog/create-car-dialog.component';
import {MatSnackBar} from "@angular/material/snack-bar";
import * as _ from 'underscore';
import {EditCarDialogComponent} from "./edit-car-dialog/edit-car-dialog.component";

@Component({
  selector: "app-cars",
  templateUrl: "./cars.component.html",
  styleUrls: ["./cars.component.css"],
})
export class CarsComponent implements OnInit {
  cars: Car[];

  displayedColumns = ["carTypeName", "marketPrice", "dailyRentPrice", "update", "delete"];

  constructor(private httpClient: HttpClient,
              private carClient: CarsClient,
              private matDialog: MatDialog,
              private snackbar: MatSnackBar) {
  }

  ngOnInit(): void {
    this.carClient.getAllCars(undefined).subscribe((cars) => {
      this.cars = cars;
      this.cars.forEach((car) => {
        car.carTypeName = CarType[car.type].toString();
      });
    });
  }

  addNewCar() {
    const dialogReference = this.matDialog.open(CreateCarDialogComponent);

    dialogReference.afterClosed().subscribe(result => {
      if (result) {
        this.cars = [...this.cars, result];
        this.snackbar.open("Successfully created car.",
          "Close", {
            duration: 5000
          });
      }
    })
  }

  deleteCar(element): void {
    this.carClient.delete(element.id).subscribe((result) => {
      console.log(result);
      this.cars = _.without(this.cars, element);
    });
  }

  updateCar(element) {
    const dialogReference = this.matDialog.open(EditCarDialogComponent,
      {
        data: element
      });

    dialogReference.afterClosed().subscribe(() => {
      this.snackbar.open("Successfully updated car!", "Close",
        {
          duration: 5000
        });
    })
  }
}
