import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
    constructor(private snackbar: MatSnackBar) {}

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            tap(
                (event) => {
                    if (event instanceof HttpResponse) {
                        // shows success snackbar with green background
                        this.snackbar.open(event.statusText, 'Close', {
                            duration: 2000,
                            panelClass: ['green-snackbar']
                        });
                    }
                },
                (error) => {
                    const isLoginUrl = req.url.includes('authentication/login');
                    const isRefreshUrl = req.url.includes('authentication/refresh');

                    // http response status code
                    if (error.status === 500) {
                        if (!isRefreshUrl) {
                            this.snackbar.open(
                                `Hiba történt, vegye fel a kapcsolatot a fejlesztőkkel: ${error.message}`,
                                'Close',
                                {
                                    duration: 10000,
                                }
                            );
                        }
                    }

                    if (error.status === 403) {
                        this.snackbar.open(
                            `Nincs jogosultsága megtekinteni ezeket az adatokat. Amennyiben mégis szüksége lenne rá,
                         úgy vegye fel a kapcsolatot a fejlesztőkkel: ${error.message}`,
                            'Close',
                            {
                                duration: 10000,
                            }
                        );
                    }

                    if (error.status === 401) {
                        if (isLoginUrl) {
                            this.snackbar.open(`${error.error}`, 'Close', {
                                duration: 5000,
                            });
                        }
                    }

                    if (error.status === 400) {
                        if (!isRefreshUrl) {
                            this.snackbar.open(`Hiba történt: ${error.message}`, 'Close', {
                                duration: 5000,
                            });
                        }
                    }
                }
            )
        );
    }
}
