from django.conf.urls import patterns, include, url

from django.contrib import admin
from rest_framework import viewsets, routers
from datamanager.models import Restaurant

admin.autodiscover()


class RestaurantViewSet(viewsets.ModelViewSet):
    model = Restaurant

# Routers provide an easy way of automatically determining the URL conf
router = routers.DefaultRouter()
router.register(r'restaurants', RestaurantViewSet)

urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'data_source.views.home', name='home'),
    # url(r'^blog/', include('blog.urls')),

    url(r'^', include(router.urls)),
    url(r'^admin/', include(admin.site.urls)),
    url(r'^api-auth/', include('rest_framework.urls', namespace='rest_framework'))
)
