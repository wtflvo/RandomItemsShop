import { Component, OnInit, ViewChild } from '@angular/core';
import {
  PasswordErrorMatcher,
  checkPasswords,
} from 'src/app/custom-mat-elems/error matchers/passwordeErrorMatcher/passwordMatchers';
import {
  
  FormGroup,
  Validators,
  FormBuilder,
  AbstractControlOptions,
  FormGroupDirective,
} from '@angular/forms';
import { User } from 'src/app/interfaces/User';


import { AddUserService } from 'src/app/services/addUser/add-user.service';
import { Router } from '@angular/router';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css'],
})
export class RegistrationComponent {
  matcher = new PasswordErrorMatcher();

  newUserForm: FormGroup;
  responseMessage!: string;

  constructor(
    private addUser: AddUserService,
    private formBuilder: FormBuilder,
    private router: Router,
  ) {
    this.newUserForm = this.formBuilder.group(
      {
        addName: ['', [Validators.required, Validators.minLength(3)]],
        addEmail: ['', [Validators.required, Validators.minLength(5)]],
        addPassword: ['', [Validators.required, Validators.minLength(3)]],
        repeatPassword: ['', [Validators.required]],
      },
      { validators: [checkPasswords] } as AbstractControlOptions
    );
  }
  @ViewChild(FormGroupDirective)
  formDirective!: FormGroupDirective;

 async submit() {
    console.log(this.newUserForm.value, 'formvalue');
    const { addName, addEmail, addPassword } = this.newUserForm.value;

    const newUser: User = {
      name: addName ?? '',
      email: addEmail ?? '',
      password: addPassword ?? '',
   };
   this.addUser.sendUser(newUser).subscribe((data: string) => {
     this.responseMessage = data;

     if (this.responseMessage === 'Sign up successfull!') {
       
       this.formDirective.resetForm();
       setTimeout(() => {
         this.responseMessage = '';
         this.router.navigate(['/enter']);
       }, 2500)
     }
   });
   
      
    
      
  }
  ngOnInit(): void {}
}
