import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms'; // Needed for ngModel
 
@Component({
  selector: 'app-teachers',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent {
  selectedSubject = 'All Subjects';
  searchTerm = '';
  showModal = false;
 
  teachers = [
    {
      name: 'Dr. Emily Roberts',
      ref: 'TCH001',
      email: 'emily.roberts@school.edu',
      phone: '(555) 111-2222',
      qualification: 'PhD',
      subject: 'Mathematics',
      classes: ['Grade 10A', 'Grade 11A'],
      status: 'Active'
    },
    {
      name: 'Prof. Michael Chen',
      ref: 'TCH002',
      email: 'michael.chen@school.edu',
      phone: '(555) 333-4444',
      qualification: 'MSc Physics',
      subject: 'Physics',
      classes: ['Grade 11B', 'Grade 12A'],
      status: 'Active'
    },
    {
      name: 'Ms. Sarah Johnson',
      ref: 'TCH003',
      email: 'sarah.johnson@school.edu',
      phone: '(555) 555-6666',
      qualification: 'MA English',
      subject: 'English Literature',
      classes: ['Grade 9A', 'Grade 9B'],
      status: 'Active'
    }
  ];
}