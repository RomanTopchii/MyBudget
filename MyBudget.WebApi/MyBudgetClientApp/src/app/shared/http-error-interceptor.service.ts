import {Injectable} from '@angular/core';
import {HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest} from '@angular/common/http';
import {NotificationService} from '@progress/kendo-angular-notification';
import {catchError, Observable, throwError} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpErrorInterceptorService implements HttpInterceptor {
  constructor(private readonly notificationService: NotificationService) {
    console.error('Interceptor');
  }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req)
      .pipe(
        catchError((error: HttpErrorResponse) => {

          let message = 'An unexpected error occurred.';

          if (error.error instanceof ErrorEvent) {
            // Client-side or network error
            message = `Client-side error: ${error.error.message}`;
          } else {
            // Backend error
            message = `Error ${error.status}: ${error.message}`;
            if (error.error?.message) {
              message = error.error.message;
            }
          }

          this.notificationService.show({
            content: message,
            hideAfter: 5000,
            position: {horizontal: 'right', vertical: 'top'},
            animation: {type: 'fade', duration: 400},
            type: {style: 'error', icon: true}
          });

          return throwError(() => error);
        })
      );
  }
}
