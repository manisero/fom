from django import forms
from re import match
from datamanager.models import Restaurant


class RestaurantForm(forms.ModelForm):
    class Meta:
        model = Restaurant

    def clean_phone_number(self):
        phone_number = self.cleaned_data['phone_number']
        self.validate_phone_number(phone_number)

        return phone_number

    @staticmethod
    def validate_phone_number(phone_number):
        if phone_number is None or match('^\d{9}$', phone_number) is None:
            raise forms.ValidationError('Phone number is invalid')
