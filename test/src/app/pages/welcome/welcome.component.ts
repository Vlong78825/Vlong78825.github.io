import { Component, Input, OnInit } from '@angular/core';
import { TinhthanhService } from 'src/app/service/tinhthanh.service';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzInputModule } from 'ng-zorro-antd/input';
import { FormsModule } from '@angular/forms';
import { Data } from '@angular/router';

interface Person {
  thanhpho: string;
  quanHuyen: string;
}
interface DataItem {
  name: string;
  age: number;
  address: string;
}
@Component({
  selector: 'app-welcome',
  templateUrl: './welcome.component.html',
  styleUrls: ['./welcome.component.css'],

    


})
export class WelcomeComponent implements OnInit {
  constructor(private service: TinhthanhService) { }
  TinhThanhList: any[] = [ ]
  id2?:number
  thanhpho?: string;
  quanhuyen?: string;
  isVisible = false;
  isVisible2 = false;
  searchValue = '';
  visible = false;
  listOfDisplayData = [...this.TinhThanhList];

  ngOnInit() {
    this.refreshTinhThanhList();
  }
  refreshTinhThanhList() {
    this.service.getTinhthanh().subscribe(data => { this.TinhThanhList = data,this.search() })
  }

  showModal(): void {
    this.isVisible = true;
    this.id2=0;
  }
  showModal2(any:number,any2:string,any3:string): void {
    this.isVisible2 = true;
    this.id2=any;
    this.thanhpho =any2;
    this.quanhuyen =any3;

  }
  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVisible = false;
    this.thanhpho =null!;
    this.quanhuyen =null!;
  }

  handleCancel2(): void {
    console.log('Button cancel clicked!');
    this.isVisible2 = false;
    this.thanhpho =null!;
    this.quanhuyen =null!;
  }
  handleAdd(): void {
    console.log('Button ok clicked!');
    var val = { addid:this.id2,thanhPho: this.thanhpho, quanHuyen: this.quanhuyen };
    this.service.postTinhthanh(val).subscribe(()=> {this.refreshTinhThanhList()} );
    this.isVisible = false;
    this.thanhpho =null!;
    this.quanhuyen =null!;
  }
  handleDel(any:number){
    this.service.deleteTinhthanh(any).subscribe(()=> {this.refreshTinhThanhList()} );
  }
  handlePut(){   
    var val = { id:this.id2,thanhPho: this.thanhpho, quanHuyen: this.quanhuyen };
    this.service.putTinhthanh(val,this.id2!).subscribe(()=> {this.refreshTinhThanhList()} );
    this.thanhpho =null!;
    this.quanhuyen =null!;
    this.isVisible2 = false;
  }
  
  reset(): void {
    this.searchValue = '';
    this.search();
  }

  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.TinhThanhList.filter((item: any) => item.thanhPho.indexOf(this.searchValue) !== -1);
  }
}

