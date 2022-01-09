export class UpdateOrderModel {

  constructor(customerOrderNo: string, status: number) {
    this.customerOrderNo = customerOrderNo;
    this.statusValue = status;
  }

  customerOrderNo: string;
  statusValue: number;
}
