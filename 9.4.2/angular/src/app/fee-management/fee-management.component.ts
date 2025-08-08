import { Component, Injector, OnInit, Input, ChangeDetectorRef } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { LucideAngularModule, DollarSign, Edit, Trash2, Plus } from 'lucide-angular';
import { PaymentStructureServiceProxy, PaymentStructureRequestDTO, PaymentStructureUpdateDTO, PaymentStructureResponseDTO } from '../../shared/service-proxies/service-proxies';
import { finalize } from 'rxjs/operators';

@Component({
  selector: 'app-fee-management',
  standalone: true,
  imports: [CommonModule, LucideAngularModule, FormsModule, ReactiveFormsModule],
  templateUrl: './fee-management.component.html',
  styleUrls: ['./fee-management.component.css']
})
export class FeeManagementComponent implements OnInit {
  @Input() groupId: number = 1;
  showModal = false;
  feeTypes: PaymentStructureResponseDTO[] = [];
  newFeeType: Partial<PaymentStructureRequestDTO> = {};
  isEditMode = false;
  editingFeeId: number | null = null;
  isSubmitting = false;

  readonly DollarSign = DollarSign;
  readonly Edit = Edit;
  readonly Trash2 = Trash2;
  readonly Plus = Plus;

  constructor(
    private paymentService: PaymentStructureServiceProxy,
    private injector: Injector,
    private cdRef: ChangeDetectorRef
  ) {}

  ngOnInit(): void {
    if (this.groupId) {
      this.loadFeeTypes();
    }
  }

  loadFeeTypes(): void {
    this.paymentService.getAllPaymentStructure(this.groupId).subscribe({
      next: (res) => {
        this.feeTypes = res.result ?? [];
        this.cdRef.markForCheck();
      },
      error: (err) => {
        console.error("Error loading fee types", err);
      }
    });
  }

  openModal(): void {
    this.newFeeType = {};
    this.isEditMode = false;
    this.editingFeeId = null;
    this.showModal = true;
  }

  closeModal(): void {
    this.showModal = false;
  }

  saveNewFeeType(): void {
    if (this.isSubmitting || !this.newFeeType.name) return;
    this.isSubmitting = true;

    this.newFeeType.groupId = this.groupId;

    if (this.isEditMode && this.editingFeeId !== null) {
      // Edit mode
      const payload: PaymentStructureUpdateDTO = new PaymentStructureUpdateDTO({
        id: this.editingFeeId,
        name : this.newFeeType.name,
        newName : this.newFeeType.name,
        groupId: this.groupId
      });
      this.paymentService.updatePaymentStructure(payload)
        .pipe(finalize(() => this.isSubmitting = false))
        .subscribe({
          next: () => {
            this.loadFeeTypes();
            this.closeModal();
          },
          error: (err) => {
            console.error('Error updating fee', err);
          }
        });
    } else {
      this.paymentService.createPaymentStructure(this.newFeeType as PaymentStructureRequestDTO)
        .pipe(finalize(() => this.isSubmitting = false))
        .subscribe({
          next: () => {
            this.loadFeeTypes();
            this.closeModal();
          },
          error: (err) => {
            console.error('Error adding fee', err);
          }
        });
    }
  }

  onEditFee(feeId: number): void {
    const feeToEdit = this.feeTypes.find((f) => f.id === feeId);
    if (feeToEdit) {
      this.newFeeType = {
        name: feeToEdit.name,
        groupId: this.groupId
      };
      this.isEditMode = true;
      this.editingFeeId = feeId;
      this.showModal = true;
    }
  }

  onDeleteFee(feeId: number): void {
    if (!confirm('Are you sure you want to delete this fee?')) return;

    this.paymentService.delete(feeId).subscribe({
      next: () => {
        this.loadFeeTypes();
      },
      error: (err) => {
        console.error('Error deleting fee', err);
      }
    });
  }

  getStatusClass(status: string): string {
    return status.toLowerCase() === 'active' ? 'status-active' : 'status-inactive';
  }
}