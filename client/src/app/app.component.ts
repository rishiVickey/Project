import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { IPagination } from './shared/Models/Pagination';
import { IProduct } from './shared/Models/Product';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  title = 'Fly Buy';
  

  constructor(){} 

  ngOnInit(): void {
    
  }
  



}
