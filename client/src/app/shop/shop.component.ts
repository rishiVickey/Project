import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { IBrand } from '../shared/Models/brand';
import { IProduct } from '../shared/Models/Product';
import { IType } from '../shared/Models/ProductType';
import { ShopParams } from '../shared/Models/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search',{static:true}) searchTerm:ElementRef;
  products:IProduct[];
  brands:IBrand[];
  types:IType[];
  shopParams = new ShopParams();
  totalCount:number;
  sortOptions = [
    {name:'Alphabetical',value:'name'},
    {name:'price:Low to High',value :'priceAsc'},
    {name:'price:High to Low',value:"priceDesc"}
  ];

  constructor(private ShopService :ShopService) { }

  ngOnInit(): void {
    this.getProducts();
    this.getBrands();
    this.getTypes();

  }

getProducts(){
  this.ShopService.getProducts(this.shopParams).subscribe(response => {
    this.products = response.data;
    this.shopParams.pageNumber = response.pageIndex;
    this.shopParams.pageSize = response.pagesize;
    this.totalCount = response.count;
},error =>{
  console.log(error)
});
}

getBrands(){
  this.ShopService.getBrands().subscribe(res => {this.brands= [{id:0 ,name:'All'},...res];},error =>{
    console.log(error);
  });
}

getTypes(){
  this.ShopService.getTypes().subscribe(res => {this.types = [{id:0 ,name:'All'},...res];},error => {
    console.log(error)
  });
}

onBrandSelected(brandId:number){
  this.shopParams.brandId = brandId;
  this.shopParams.pageNumber=1;
  this.getProducts();
}

onTypeSelected(typeId:number){
   this.shopParams.typeId = typeId;
   this.getProducts();
}

onSortSelected(sort:string){
  this.shopParams.sort = sort;
  this.getProducts();
}

onPageChanged(event:any){
  
    if(this.shopParams.pageNumber !== event){
      this.shopParams.pageNumber = event;
      this.getProducts();    
    }
}

onSearch(){
  this.shopParams.search = this.searchTerm.nativeElement.value;
  this.shopParams.pageNumber=1;
  this.getProducts();
}

}
