import { Observable, throwError as _observableThrow, of as _observableOf } from "rxjs";
import { InjectionToken } from "@angular/core";
import { RequestException } from "./Exceptions";

export const API_BASE_URL = new InjectionToken<string>('API_BASE_URL');

export class BaseService {

    blobToText(blob: any): Observable<string> {
        return new Observable<string>((observer: any) => {
            if (!blob) {
                observer.next("");
                observer.complete();
            } else {
                let reader = new FileReader(); 
                reader.onload = event => { 
                    observer.next((<any>event.target).result);
                    observer.complete();
                };
                reader.readAsText(blob); 
            }
        });
    }

    throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): Observable<any> {
        if (result !== null && result !== undefined)
            return _observableThrow(result);
        else
            return _observableThrow(new RequestException(message, status, response, headers, null));
    }
}
