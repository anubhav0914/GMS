import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LucideAngularModule, DollarSign, Edit, Trash2, Plus } from 'lucide-angular';

export interface FeeType {
  id: string;
  name: string;
  amount: number;
  description: string;
  frequency: string;
  status: 'Active' | 'Inactive';
}

@Component({
  selector: 'app-fee-management',
  standalone: true,
  imports: [CommonModule, LucideAngularModule],
  templateUrl: './fee-management.component.html',
  styleUrls: ['./fee-management.component.css']
})
export class FeeManagementComponent {
  // Register Lucide icons
  readonly DollarSign = DollarSign;
  readonly Edit = Edit;
  readonly Trash2 = Trash2;
  readonly Plus = Plus;

  feeTypes: FeeType[] = [
    {
      id: '1',
      name: 'Tuition Fee',
      amount: 1200,
      description: 'Monthly tuition fee',
      frequency: 'Monthly',
      status: 'Active'
    },
    {
      id: '2',
      name: 'Lab Fee',
      amount: 150,
      description: 'Laboratory usage fee',
      frequency: 'Monthly',
      status: 'Active'
    },
    {
      id: '3',
      name: 'Library Fee',
      amount: 50,
      description: 'Library access fee',
      frequency: 'Monthly',
      status: 'Active'
    },
    {
      id: '4',
      name: 'Sports Fee',
      amount: 100,
      description: 'Sports facilities fee',
      frequency: 'Monthly',
      status: 'Active'
    },
    {
      id: '5',
      name: 'Annual Fee',
      amount: 500,
      description: 'Annual registration fee',
      frequency: 'Monthly',
      status: 'Active'
    },
    {
      id: '6',
      name: 'Exam Fee',
      amount: 75,
      description: 'Examination processing fee',
      frequency: 'Monthly',
      status: 'Active'
    }
  ];

  constructor() {}

  onAddFeeType(): void {
    console.log('Add fee type clicked');
    // Implementation for adding new fee type
  }

  onEditFee(feeId: string): void {
    console.log('Edit fee clicked for ID:', feeId);
    // Implementation for editing fee
  }

  onDeleteFee(feeId: string): void {
    console.log('Delete fee clicked for ID:', feeId);
    // Implementation for deleting fee
  }

  getStatusClass(status: string): string {
    return status.toLowerCase() === 'active' ? 'status-active' : 'status-inactive';
  }
}
