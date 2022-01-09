export class Order {

  constructor(customerOrderNo: string, statusValue: number) {
    this.customerOrderNo = customerOrderNo;
    this.statusValue = statusValue;
  }

  customerOrderNo: string;
  departureAddress: string;
  destinationAddress: string;
  quantity: number;
  quantityType: string;
  weight: number;
  weightType: number;
  productCode: string;
  note: string;
  status: string;
  statusValue: number;
}
