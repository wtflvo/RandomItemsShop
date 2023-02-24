import { ErrorStateMatcher } from '@angular/material/core';
import { FormControl, FormGroup, ValidationErrors } from '@angular/forms';

export class PasswordErrorMatcher implements ErrorStateMatcher {
  isErrorState(control: FormControl): boolean {
    const controlInvalid = control.touched && control.invalid;
    const formInvalid =
      control.touched &&
      control.parent?.get('repeatPassword')?.touched &&
      control.parent.invalid;
    return !!controlInvalid || !!formInvalid;
  }
}

export function checkPasswords(group: FormGroup): ValidationErrors | null {
  const pass = group.controls.addPassword.value;
  const confirmPass = group.controls.repeatPassword.value;
  return pass === confirmPass ? null : { notSame: true };
}
