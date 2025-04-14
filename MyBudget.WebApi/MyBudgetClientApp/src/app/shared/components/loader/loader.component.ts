import { Component } from '@angular/core';
import {LoaderService} from '../../loader.service';
import {NgIf} from '@angular/common';

@Component({
  selector: 'app-loader',
  imports: [
    NgIf
  ],
  templateUrl: './loader.component.html',
  styleUrl: './loader.component.scss'
})
export class LoaderComponent {
  isLoading: boolean = false;

  constructor(private loaderService: LoaderService) {}

  ngOnInit(): void {
    this.loaderService.loaderState$.subscribe((state) => {
      this.isLoading = state;
    });
  }
}
