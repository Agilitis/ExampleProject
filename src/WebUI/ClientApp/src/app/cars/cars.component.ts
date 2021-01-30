import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Car, CarsClient, CarType, GetAllCarsQuery, ICar } from '../web-api-client';

@Component({
  selector: "app-cars",
  templateUrl: "./cars.component.html",
  styleUrls: ["./cars.component.css"],
})
export class CarsComponent implements OnInit {
  cars: Car[];

  displayedColumns = ["carTypeName", "marketPrice", "dailyRentPrice", "delete"];
  constructor(private httpClient: HttpClient, private carClient: CarsClient) {}

  ngOnInit(): void {
    this.carClient.getAllCars(undefined).subscribe((cars) => {
      this.cars = cars;
      this.cars.forEach((car) => {
        car.carTypeName = CarType[car.type].toString();
      });
      console.log(this.cars);
    });
  }

  deleteCar(element): void {
    this.carClient.delete(element.id).subscribe((result) => {
      console.log(result);
    });
  }
}
