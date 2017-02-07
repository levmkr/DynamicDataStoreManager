Vue.component('stores-template', {
    beforeMount: function () {
        this.initStores();
    },
    data: function () {
        return {
            stores: [],
            mappings: [],
            showMappings: false,
            currentStoreData: []
        }
    },
    methods: {
        initStores: function () {
            var vm = this;
            $.get('/getstores', function (stores) {
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
                $.get('/GetStoreData', { storeName: store.Name }, function (items) {
                    if (items.length === 0) {
                        vm.mappings = store.Mappings;
                    } else {
                        vm.currentStoreData = items;
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

Vue.component('mappings-template', {
    props: {
        mappings: Array,
        data: Array
    },
    template: '#mappings-template'
});

var ddsList = new Vue({
    el: '#dds',
    methods: {
        getStores: function() {
            $.get('/getstores', function (stores) {
                return stores;
            })
            .fail(function () {
                console.log('fail');
            });
        }
    }
});
