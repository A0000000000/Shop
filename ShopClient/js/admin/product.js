$(function() {
    window.vm = new Vue({
        el: '#app',
        data () {
            return {
                list: [],
                name: '',
                price: 0,
                repository: 0,
                kind: '',
                supplier: '',
                message: '',
                token: ''
            };
        },
        methods: {
            addNewProduct () {
                axios.post('https://127.0.0.1:44360/api/product/addnewproduct', {
                    name: this.name,
                    price: this.price,
                    repository: this.repository,
                    kind: this.kind,
                    supplier: this.supplier,
                    message: this.message
                }, {
                    headers: {
                        token: this.token
                    }
                }).then(function(response) {
                    let data = response.data;
                    if (data.status === 'success') {
                        alert(data.message);
                        location.reload();
                    } else {
                        alert(data.message);
                    }
                }).catch(function(error) {
                    console.log(error);
                });
            },
            deleteItem (index) {
                let item = this.list[index];
                axios.post('https://127.0.0.1:44360/api/product/deleteproduct', item, {
                    headers: {
                        token: this.token
                    }
                }).then(function(response) {
                    let data = response.data;
                    if (data.status === 'success') {
                        alert(data.message);
                        location.reload();
                    } else {
                        alert(data.message);
                    }
                }).catch(function(error) {
                    console.log(error);
                });
            }
        }
    });
    let token = window.localStorage.getItem('ShopAdminLoginTOKEN');
    window.vm.token = token;
    axios.post('https://127.0.0.1:44360/api/product/getallproducts', { }, {
        headers: {
            token
        }
    }).then(function(response) {
        let data = response.data;
        window.vm.list = data;  
    }).catch(function(error) {
        console.log(error);
    });
});