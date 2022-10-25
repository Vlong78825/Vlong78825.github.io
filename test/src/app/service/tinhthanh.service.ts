import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TinhthanhService {
  readonly APIUrl="http://localhost:5271/api/tinhthanh2"
  readonly mockApi = "https://63514a643e9fa1244e5abe49.mockapi.io/Person"
  constructor(private http:HttpClient ){ }
  getTinhthanh():Observable<any>{
    return this.http.get<any[]> (this.APIUrl)
  }
  postTinhthanh(val:any){
    return this.http.post(this.APIUrl,val)
  }
  putTinhthanh(val:any,id:number){
    return this.http.put(this.APIUrl+'/'+id,val)
  }
  deleteTinhthanh(id:number){
    return this.http.delete(this.APIUrl+'/'+id)
  }
  
}
