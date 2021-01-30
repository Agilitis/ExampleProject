import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { TodoComponent } from './todo/todo.component';
import { ApiAuthorizationModule } from 'src/api-authorization/api-authorization.module';
import { AuthorizeGuard } from 'src/api-authorization/authorize.guard';
import { AuthorizeInterceptor } from 'src/api-authorization/authorize.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ModalModule } from 'ngx-bootstrap/modal';
import { CarPartsComponent } from './car-parts/car-parts.component';
import { CarsComponent } from './cars/cars.component';
import { RentsComponent } from './rents/rents.component';
import { ServicePartnersComponent } from './service-partners/service-partners.component';
import { ServicesComponent } from './services/services.component';
import { ApiInterceptor } from "src/app/interceptors/ApiInterceptor";
import { MatTableModule } from "@angular/material/table";
import { MatButtonModule } from "@angular/material/button";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    TodoComponent,
    CarPartsComponent,
    CarsComponent,
    RentsComponent,
    ServicePartnersComponent,
    ServicesComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: "ng-cli-universal" }),
    FontAwesomeModule,
    HttpClientModule,
    FormsModule,
    ApiAuthorizationModule,
    RouterModule.forRoot([
      { path: "", component: HomeComponent, pathMatch: "full" },
      { path: "counter", component: CounterComponent },
      { path: "fetch-data", component: FetchDataComponent },
      { path: "todo", component: TodoComponent, canActivate: [AuthorizeGuard] },
      { path: "cars", component: CarsComponent, canActivate: [AuthorizeGuard] },
      {
        path: "car-parts",
        component: CarPartsComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: "rents",
        component: RentsComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: "service-partners",
        component: ServicePartnersComponent,
        canActivate: [AuthorizeGuard],
      },
      {
        path: "services",
        component: ServicesComponent,
        canActivate: [AuthorizeGuard],
      },
    ]),
    BrowserAnimationsModule,
    MatTableModule,
    MatButtonModule,
    ModalModule.forRoot(),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthorizeInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
