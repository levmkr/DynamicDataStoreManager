Vue.component('stores-template', {
    beforeMount: function () {
        this.initStores();
    },
    data: function () {
        return {
            stores: [],
            mappings: [],
            showMappings: '',
            currentStoreData: []
        };
    },

    methods: {
        initStores: function () {
            var vm = this;
            $.get('/custom-plugins/dds-plugin/getstores', function (stores) {
                vm.stores = stores;
            })
            .fail(function () {
                console.log('fail');
            });
        },
        toggleMappingsTable: function (store) {
            this.currentStoreData = [];
            this.mappings = [];

            if (this.showMappings === store.Name) {
                this.showMappings = "";
            } else {
                this.showMappings = store.Name;

                var vm = this;
                $.get('/custom-plugins/dds-plugin/getstoredata', { storeName: store.Name }, function (items) {
                    if (items.length === 0) {
                        vm.mappings = store.Mappings;
                    } else {
                        vm.currentStoreData = items;
                        items.forEach(function (item) {
                            item["action"] = item.Id;
                        });

                        for (var property in items[0]) {
                            if (items[0].hasOwnProperty(property)) {
                                vm.mappings.push(property);
                            }
                        }
                    }
                })
                .fail(function () {
                    console.log('fail');
                });
            }
        }
    },
    template: '#stores-template'
});

Vue.component('items-template', {
    props: {
        mappings: Array,
        data: Array,
        currentStoreName: ''
    },
    methods: {
        removeItemFromList: function (index) {
            if (index !== -1) {
                this.data.splice(index, 1);
                console.log(index);
            }
        }
    },
    template: '#items-template'
});

Vue.component('item-template', {
    props: {
        value: '',
        mapping: '',
        currentIndex: '',
        currentStoreName: ''
    },
    methods: {
        deleteItem: function (value) {
            var vm = this;
            $.post('/custom-plugins/dds-plugin/deletestoreitem', { externalId: value.ExternalId, storeId: value.StoreId, storeName: vm.currentStoreName }, function () {
                vm.$parent.removeItemFromList(vm.currentIndex);
                console.log('success');
            })
            .fail(function () {
                console.log('fail');
            });
        }
    },
    template: '#item-template'
});

var ddsList = new Vue({
    el: '#dds',
    methods: {
    }
});



$(".less .button").click(function () {

    var $el = $(this),
        $p = $el.parent(),
        $up = $p.parent(),
        $ps = $up.find("div:not('.more-link')"),
        totalHeight = 0;

    // measure how tall inside should be by adding together heights of all inside paragraphs (except read-more paragraph)
    $ps.each(function () {
        totalHeight += $(this).outerHeight();
    });

    $up
      .css({
          // Set height to prevent instant jumpdown when max height is removed
          "height": $up.height(),
          "max-height": 9999
      })
      .animate({
          "height": totalHeight
      });

    // fade out read-more
    $p.fadeOut();

    // prevent jump-down
    return false;

});