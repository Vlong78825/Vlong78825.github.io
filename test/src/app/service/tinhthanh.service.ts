import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TinhthanhService {
  readonly APIUrl="http://localhost:5019/api/"

  constructor(private http:HttpClient ){ }
  
  getThanhPho():Observable<any>{
    return this.http.get<any[]> (this.APIUrl+'ThanhPhos')
  }
  getThanhPhoByTen(val?:string):Observable<any>{
    return this.http.get<any[]> (this.APIUrl+'ThanhPhos/'+val)
  }
  getThanhPhoById(val:number):Observable<any>{
    return this.http.get<any[]> (this.APIUrl+'ThanhPhos/'+val)
  }
  getQuanHuyen():Observable<any>{
    return this.http.get<any[]> (this.APIUrl+'QuanHuyen')
  }
  postThanhPho(val:any){
    return this.http.post(this.APIUrl+'ThanhPhos',val)
  }
  postQuanHuyen(val:any){
    return this.http.post(this.APIUrl+'QuanHuyen',val)
  }
  putThanhPho(val:any,id:number){
    return this.http.put(this.APIUrl+'ThanhPhos/'+id,val)
  }
  putQuanHuyen(val:any,id?:number){
    return this.http.put(this.APIUrl+'QuanHuyen/'+id,val)
  }
  deleteThanhPho(id:number){
    return this.http.delete(this.APIUrl+'ThanhPhos/'+id)
  }
  deleteQuanHuyen(id:number){
    return this.http.delete(this.APIUrl+'QuanHuyen/'+id)
  }
  getTinhThanh():Observable<any>{
    return this.http.get<any[]> (this.APIUrl+'QuanHuyen/withThanhPho')
  
  }
 
}
