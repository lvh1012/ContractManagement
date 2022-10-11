import { ProductEnum } from './enum/product.enum';
import { Component, OnInit } from '@angular/core';
import { ConfirmationService } from 'primeng/api';
import { MessageService } from 'primeng/api';
import { Product } from './models/product';
import { ProductService } from './services/product.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {

  openDialog: boolean = false;

  products: Product[] = [];

  product: Product = {};

  selectedRows: Product[] = [];

  submitted: boolean = false;

  statuses: any[] = [];

  units: any[] = [
    {
      name: 'Cái',
      code: ProductEnum.CAI
    },
    {
      name: 'Chiếc',
      code: ProductEnum.CHIEC
    },
    {
      name: 'Bộ',
      code: ProductEnum.BO
    }
  ];

  constructor(private productService: ProductService, private messageService: MessageService, private confirmationService: ConfirmationService) { }

  ngOnInit() {
    this.productService.getProducts().then(data => this.products = data);
  }

  openNew() {
    this.product = {};
    this.submitted = false;
    this.openDialog = true;
  }

  deleteSelected() {
    this.confirmationService.confirm({
      message: 'Bạn có chắn chắn muốn xóa những sản phẩm này không?',
      header: 'Xác nhận',
      acceptLabel: 'Có',
      rejectLabel: 'Không',
      icon: 'pi pi-exclamation-triangle',
      accept: () => {
        this.products = this.products.filter(val => !this.selectedRows.includes(val));
        this.selectedRows = [];
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Products Deleted', life: 3000 });
      }
    });
  }

  edit(product: Product) {
    this.product = { ...product };
    this.openDialog = true;
  }

  delete(product: Product) {
    this.confirmationService.confirm({
      message: 'Bạn có chắn chắn muốn xóa ' + product.name + '?',
      header: 'Xác nhận',
      icon: 'pi pi-exclamation-triangle',
      acceptLabel: 'Có',
      rejectLabel: 'Không',
      accept: () => {
        this.products = this.products.filter(val => val.id !== product.id);
        this.product = {};
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Deleted', life: 3000 });
      }
    });
  }

  hideDialog() {
    this.openDialog = false;
    this.submitted = false;
  }

  save() {
    this.submitted = true;

    if (this.product.name?.trim()) {
      if (this.product.id) {
        this.products[this.findIndexById(this.product.id)] = this.product;
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Updated', life: 3000 });
      }
      else {
        this.product.id = this.createId();
        this.products.push(this.product);
        this.messageService.add({ severity: 'success', summary: 'Successful', detail: 'Product Created', life: 3000 });
      }

      this.products = [...this.products];
      this.openDialog = false;
      this.product = {};
    }
  }

  findIndexById(id: string): number {
    let index = -1;
    for (let i = 0; i < this.products.length; i++) {
      if (this.products[i].id === id) {
        index = i;
        break;
      }
    }

    return index;
  }

  createId(): string {
    let id = '';
    var chars = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
    for (var i = 0; i < 5; i++) {
      id += chars.charAt(Math.floor(Math.random() * chars.length));
    }
    return id;
  }

}
