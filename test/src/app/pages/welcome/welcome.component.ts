import { Component, Input, OnInit } from '@angular/core';
import { TinhthanhService } from 'src/app/service/tinhthanh.service';
import { NzModalModule } from 'ng-zorro-antd/modal';
import { NzInputModule } from 'ng-zorro-antd/input';
import { FormsModule } from '@angular/forms';
import { Data } from '@angular/router';
import { toArray } from 'rxjs';


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
  id?:number
  thanhphoid?:number
  thanhpho?: string;
  quanhuyen?: string;
  isVisible = false;
  isVisible2 = false;
  searchValue = '';
  visible = false;
  listOfDisplayData = [...this.TinhThanhList];
  login =false;
  passwordVisible=false;
  username?: string;
  password?: string;

  ngOnInit() {
    this.refreshTinhThanhList();
  }
  refreshTinhThanhList() {
    this.service.getTinhThanh().subscribe(data => { this.TinhThanhList = data,this.search()})
  }

  showModal(): void {
    this.isVisible = true;
    this.thanhpho =null!;
    this.quanhuyen =null!;
    this.id=0;
  }
  showModal2(id:number,tenQuanHuyen:string,tenThanhPho:string,ThanhPhoId:number): void {
    this.isVisible2 = true;
    this.id=id;
    this.thanhpho =tenThanhPho;
    this.quanhuyen =tenQuanHuyen;
    this.thanhphoid=ThanhPhoId;

  }
  handleCancel(): void {
    console.log('Button cancel clicked!');
    this.isVisible = false;
    this.thanhphoid=0;
  }

  handleCancel2(): void {
    console.log('Button cancel clicked!');
    this.isVisible2 = false;
    this.thanhphoid=0;
  }
  handleAdd(): void {
    var tp = { id:this.thanhphoid,tenThanhPho: this.thanhpho };
    this.service.postThanhPho(tp).subscribe(any =>{      
      this.service.getThanhPhoByTen(this.thanhpho).subscribe(data=> {
        var qh = { id:0,tenQuanHuyen: this.quanhuyen, thanhPhoId: data.id };
        console.log(qh)
        console.log(data)
        this.service.postQuanHuyen(qh).subscribe(()=> {
          this.refreshTinhThanhList();} )
      })
    } );
    this.isVisible = false;
  }

  handleDel(id:number,thanhPhoId:number){
    this.service.deleteQuanHuyen(id).subscribe(()=> {
      this.service.getThanhPhoById(id).subscribe(()=>{
        this.service.deleteThanhPho(thanhPhoId).subscribe(()=> {this.refreshTinhThanhList()})
      })     
      this.refreshTinhThanhList()} ); 
  }

  handlePut(){    
    this.service.getThanhPhoByTen(this.thanhpho).subscribe(data=> {
      var qh = { id:this.id,tenQuanHuyen: this.quanhuyen, thanhPhoId:this.thanhphoid };
      this.service.putQuanHuyen(qh,this.id).subscribe(()=> {this.refreshTinhThanhList()} );
    })
    this.isVisible2 = false;
  }

  reset(): void {
    this.searchValue = '';
    this.search();
  }
  
  search(): void {
    this.visible = false;
    this.listOfDisplayData = this.TinhThanhList.filter((item: any) => item.tenThanhPho.indexOf(this.searchValue) !== -1);
  }

  handlelogin(){
    var login = {username:this.username,password:this.password}
    this.service.postLogin(login).subscribe(data => {
      localStorage.setItem('token',data.token);
      this.login =true;
      this.refreshTinhThanhList();
      this.username='';
      this.password='';
  })
    console.log(localStorage.getItem('token'))   
  }
  handlelogout(){
    localStorage.setItem('token','');
    this.login =false;
  }
  handleloginadd(){
    var add={username:this.username,password:this.password}
    this.service.postLoginAdd(add).subscribe(res => console.log(res)
    )
    
  }
}

