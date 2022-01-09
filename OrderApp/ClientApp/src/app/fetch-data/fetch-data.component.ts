import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { OrderService } from '../employeeServicesModel/orderServices';
import { Order } from '../employeeServicesModel/orderClass';
import { Status } from '../employeeServicesModel/Status';
import { UpdateOrderModel } from '../employeeServicesModel/updateOrderModel';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  orders: Observable<Order[]>;
  updateOrder: Observable<UpdateOrderModel>;

  isChecked: any = false;
  isEdit: any = false;
  public customerOrderNoEdit: string;
  public orderChecked: string;
  public status: number;
  statusItem: Array<Status>;
  constructor(http: HttpClient, private orderService: OrderService, @Inject('BASE_URL') baseUrl: string) {
    //http.get<Order[]>('https://localhost:44305/api/order/getall').subscribe(result => {

    //  console.log(result);
    //  this.orders = result;
    //}, error => console.error(error));
  }


  ngOnInit() {

    this.statusItem = Array<Status>();
    this.statusItem.push(new Status(0, 'OrderTaken'));
    this.statusItem.push(new Status(1, 'OrderOnWay'));
    this.statusItem.push(new Status(2, 'DistributionCenter'));
    this.statusItem.push(new Status(3, 'OutForDistribition'));
    this.statusItem.push(new Status(4, 'Delivered'));
    this.statusItem.push(new Status(5, 'UnDelivered'));


    this.loadAllEmployees();
  }


  loadAllEmployees() {
    this.orders = this.orderService.getAllOrder();
  }

  onItemChange(value) {
    console.log(" Value is onItemChange: ", value);
    this.orderChecked = value;
  }

  loadOrderToEdit(customerOrderNo: string) {
    //console.log(this.isChecked);
    if (this.orderChecked == undefined) {
      alert("Sipariş Seçimi Yapılmadı");
    }
    else {
      this.isEdit = true;
      this.orderService.getOrderById(customerOrderNo).subscribe(order => {

        this.customerOrderNoEdit = order.customerOrderNo
        this.status = order.statusValue
      });
    }
  }

  cancel() {
    this.isEdit = false;
    this.customerOrderNoEdit = null
    this.status = null
  }

  save() {
    let updateOrder = new UpdateOrderModel(this.customerOrderNoEdit, this.status)

    this.orderService.updateOrder(updateOrder).subscribe(order => {
    }, () => {
      alert("Sipariş durumu güncellendi.");
    });
  }



}

