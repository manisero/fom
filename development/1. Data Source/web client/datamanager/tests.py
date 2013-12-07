from django.test import TestCase
from datamanager.forms import RestaurantForm


class RestaurantFormTests(TestCase):
    def test_validate_phone_number(self):
        invalid_test_restaurant_form = RestaurantForm(data={
            'name': 'Nazwa', 'address': 'Ulica', 'phone_number': '501-100-200', 'email_address': 'test@mail.pl'})
        valid_test_restaurant_form = RestaurantForm(data={
            'name': 'Nazwa', 'address': 'Ulica', 'phone_number': '501100200', 'email_address': 'test@mail.pl'})

        self.assertFalse(invalid_test_restaurant_form.is_valid())
        self.assertTrue(valid_test_restaurant_form.is_valid())
