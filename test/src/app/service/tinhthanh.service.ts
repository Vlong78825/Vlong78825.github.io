import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject,catchError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TinhthanhService {
  readonly APIUrl="http://localhost:5019/api/"

  constructor(private http:HttpClient ){ }
  
  getHeader(){
    var token = localStorage.getItem('token')
    return token? new HttpHeaders().set('Authorization', 'Bearer '+token): null;
  }
  postLoginAdd(val:any):Observable<any>{
    return this.http.post(this.APIUrl+'Login/Add',val)
  }
  postLogin(val:any):Observable<any>{
    return this.http.post(this.APIUrl+'Login',val)
  }
  getThanhPho():Observable<any>{
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
     return this.http.get<any[]> (this.APIUrl+'ThanhPhos',{headers: headers})
     
    return this.http.get<any[]> (this.APIUrl+'ThanhPhos')
  }
  getThanhPhoByTen(val?:string):Observable<any>{
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
      return this.http.get<any[]> (this.APIUrl+'ThanhPhos/'+val,{headers: headers})
    return this.http.get<any[]> (this.APIUrl+'ThanhPhos/'+val)
  }
  getThanhPhoById(val:number):Observable<any>{
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
     return this.http.get<any[]> (this.APIUrl+'ThanhPhos/'+val,{headers :headers})
    return this.http.get<any[]> (this.APIUrl+'ThanhPhos/'+val)
  }
  getQuanHuyen():Observable<any>{
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
      return this.http.get<any[]> (this.APIUrl+'QuanHuyen',{headers :headers})
    return this.http.get<any[]> (this.APIUrl+'QuanHuyen')
  }
  postThanhPho(val:any){
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
     return this.http.post(this.APIUrl+'ThanhPhos',val,{headers :headers})
    return this.http.post(this.APIUrl+'ThanhPhos',val)
  }
  postQuanHuyen(val:any){
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
     return this.http.post(this.APIUrl+'QuanHuyen',val,{headers :headers})
     
    return this.http.post(this.APIUrl+'QuanHuyen',val)
  }
  putThanhPho(val:any,id:number){
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
     return this.http.put(this.APIUrl+'ThanhPhos/'+id,val,{headers :headers})
    return this.http.put(this.APIUrl+'ThanhPhos/'+id,val)
  }
  putQuanHuyen(val:any,id?:number){
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
      return this.http.put(this.APIUrl+'QuanHuyen/'+id,val,{headers :headers})
    return this.http.put(this.APIUrl+'QuanHuyen/'+id,val)
  }
  deleteThanhPho(id:number){
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
      return this.http.delete(this.APIUrl+'ThanhPhos/'+id,{headers :headers})
    return this.http.delete(this.APIUrl+'ThanhPhos/'+id)
  }
  deleteQuanHuyen(id:number){
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
      return this.http.delete(this.APIUrl+'QuanHuyen/'+id,{headers :headers})
    return this.http.delete(this.APIUrl+'QuanHuyen/'+id)
  }
  getTinhThanh():Observable<any>{
    let headers = this.getHeader();
    if (headers instanceof HttpHeaders)
     return this.http.get<any[]> (this.APIUrl+'QuanHuyen/withThanhPho',{headers :headers})
    return this.http.get<any[]> (this.APIUrl+'QuanHuyen/withThanhPho')
  
  }
 
}
