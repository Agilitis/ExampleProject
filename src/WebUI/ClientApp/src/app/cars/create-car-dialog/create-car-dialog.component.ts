import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import {Car, CarsClient, CarType, CreateCarCommand} from "../../web-api-client";
import {MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-create-car-dialog',
  templateUrl: './create-car-dialog.component.html',
  styleUrls: ['./create-car-dialog.component.css']
})
export class CreateCarDialogComponent implements OnInit {
  carForm: FormGroup;
  carType = [];
  car = new Car();

  constructor(private carClient: CarsClient,
              public dialogRef: MatDialogRef<CreateCarDialogComponent>) { }

  ngOnInit(): void {
    for (const type in CarType) {
      if (isNaN(Number(type))) {
        this.carType.push(type.toString())
      }
    }
    this.carForm = new FormGroup({
      type: new FormControl("", [
        Validators.required
      ]),
      marketPrice: new FormControl(null, [
        Validators.required,
        Validators.min(100000)
      ]),
      dailyRentPrice: new FormControl(null, [
        Validators.required,
          Validators.min(2000)
      ])
    });
  }

  onFormSubmit() {
    const carEnumType = this.getEnumKeyByEnumValue(this.carForm.get('type').value);
    this.car.type = carEnumType;
    this.car.marketPrice = this.carForm.get('marketPrice').value;
    this.car.dailyRentPrice = this.carForm.get('dailyRentPrice').value;
    this.car.carTypeName = this.carForm.get('type').value;

    const createCarCommand = new CreateCarCommand();
    createCarCommand.type = this.car.type;
    createCarCommand.marketPrice = this.car.marketPrice;
    createCarCommand.dailyRentPrice = this.car.dailyRentPrice;

    this.carClient.create(createCarCommand).subscribe(result =>{
      this.car.id = result;
      this.dialogRef.close(this.car);
    });
  }

  private getEnumKeyByEnumValue(enumValue: string): number {
    const keys = Object.keys(CarType).filter(x => CarType[x] == enumValue);
    return keys.length > 0 ? Number.parseInt(keys[0]) : null;
  }
}
