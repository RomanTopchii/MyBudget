import {Injectable} from '@angular/core';
import {NotificationService} from '@progress/kendo-angular-notification';

@Injectable({
  providedIn: 'root'
})
export class AlertService {
  constructor(private readonly notificationService: NotificationService) {
  }

  none(message: string): void {
    this.show(message, 'none');
  }

  success(message: string): void {
    this.show(message, 'success');
  }

  warning(message: string): void {
    this.show(message, 'warning');
  }

  error(message: string): void {
    this.show(message, 'error');
  }

  info(message: string): void {
    this.show(message, 'info');
  }

  private show(message: string, style?: 'none' | 'success' | 'warning' | 'error' | 'info'): void {
    this.notificationService.show({
      content: message,
      hideAfter: 5000,
      position: {horizontal: 'right', vertical: 'top'},
      animation: {type: 'fade', duration: 400},
      type: {style: style, icon: true}
    });
  }
}
