import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Order } from './orderClass';
import { UpdateOrderModel } from './updateOrderModel';


@Injectable({
  providedIn: 'root'
})

export class OrderService {
  url = 'https://localhost:44305/api/order';
  constructor(private http: HttpClient) { }
  getAllOrder(): Observable<Order[]> {
    return this.http.get<Order[]>(this.url + '/getall');
  }
  getOrderById(customerOrderNo: string): Observable<Order> {
    return this.http.get<Order>(this.url + '/getbyId/' + customerOrderNo);
  }

  updateOrder(orderUpdate: UpdateOrderModel): Observable<UpdateOrderModel> {
    const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
    return this.http.post<UpdateOrderModel>(this.url + '/status/',
      orderUpdate, httpOptions);
  }



}
