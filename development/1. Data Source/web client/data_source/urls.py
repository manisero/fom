from django.conf.urls import patterns, include, url

from django.contrib import admin
from rest_framework import viewsets, routers
from datamanager.models import Restaurant, Dish
from datamanager.serializers import DishSerializer, RestaurantSerializer

admin.autodiscover()


class RestaurantViewSet(viewsets.ModelViewSet):
    model = Restaurant
    serializer_class = RestaurantSerializer


class DishViewSet(viewsets.ModelViewSet):
    model = Dish
    serializer_class = DishSerializer


# Routers provide an easy way of automatically determining the URL conf
router = routers.DefaultRouter()
router.register(r'restaurants', RestaurantViewSet)
router.register(r'dishes', DishViewSet)

urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'data_source.views.home', name='home'),
    # url(r'^blog/', include('blog.urls')),

    url(r'^api/', include(router.urls)),
    url(r'^admin/', include(admin.site.urls)),
    url(r'^api-auth/', include('rest_framework.urls', namespace='rest_framework'))
)
