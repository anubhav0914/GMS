import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { DashboardDto } from '../../../openapi-proxy/model/dashboardDto'; // adjust path if needed
import { DashboardProxy } from '../../../openapi-proxy'; // adjust if needed

@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  constructor(private dashboardProxy: DashboardProxy) {}

  getAdminDashboard(): Observable<DashboardDto> {
    return this.dashboardProxy.apiServicesAppDashboardGetAdminDashboardGet('body')
      .pipe(map((response: any) => response.result));  // extract the actual DashboardDto from the result
  }
}
