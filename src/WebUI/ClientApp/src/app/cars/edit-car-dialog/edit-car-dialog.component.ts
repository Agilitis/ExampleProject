import {Component, Inject, OnInit} from '@angular/core';
import {FormControl, FormGroup, Validators} from '@angular/forms';
import {Car, CarsClient, CarType, UpdateCarCommand} from "../../web-api-client";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";

@Component({
  selector: 'app-edit-car-dialog',
  templateUrl: './edit-car-dialog.component.html',
  styleUrls: ['./edit-car-dialog.component.css']
})
export class EditCarDialogComponent implements OnInit {
  carForm: FormGroup;
  carType = [];
  car = new Car();

  constructor(private carClient: CarsClient,
              public dialogRef: MatDialogRef<EditCarDialogComponent>,
              @Inject(MAT_DIALOG_DATA) public data: Car) { }

  ngOnInit(): void {
    this.car = this.data;
    for (const type in CarType) {
      if (isNaN(Number(type))) {
        this.carType.push(type.toString())
      }
    }
    this.carForm = new FormGroup({
      type: new FormControl(this.car.carTypeName, [
        Validators.required
      ]),
      marketPrice: new FormControl(this.car.marketPrice, [
        Validators.required,
        Validators.min(100000)
      ]),
      dailyRentPrice: new FormControl(this.car.dailyRentPrice, [
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

    const editCarCommand = new UpdateCarCommand();
    editCarCommand.type = this.car.type;
    editCarCommand.marketPrice = this.car.marketPrice;
    editCarCommand.dailyRentPrice = this.car.dailyRentPrice;
    editCarCommand.id = this.car.id;

    this.carClient.update(this.car.id, editCarCommand).subscribe(result =>{
      this.dialogRef.close();
    })
  }

  private getEnumKeyByEnumValue(enumValue: string): number {
    const keys = Object.keys(CarType).filter(x => CarType[x] == enumValue);
    return keys.length > 0 ? Number.parseInt(keys[0]) : null;
  }
}
