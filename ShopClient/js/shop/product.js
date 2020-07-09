$(function() {
    window.vm = new Vue({
        el: '#app',
        data () {
            return {
                list: [],
                token: '',
                cart: []
            };
        },
        methods: {
            AddItemToCart (index) {
                let item = this.list[index];
                this.cart.push({
                    id: item.id,
                    name: item.name,
                    price: item.price,
                    count: 1
                });
            },
            submit () {
                axios.post('https://127.0.0.1:44360/api/shop/submitorder', this.cart, {
                    headers: {
                        token: this.token
                    }
                }).then(function(response) {
                    let data = response.data;
                    if (data.status === 'failed') {
                        alert(data.message);
                    } else {
                        alert(data.message);
                        location.reload();
                    }
                }).catch(function(error) {
                    console.log(error);
                });
            }
        },
        computed: {
            Sum () {
                let sum = 0;
                this.cart.forEach(e => {
                    sum += e.price * e.count;
                });
                return sum;
            }
        }
    });
    let token = window.localStorage.getItem('ShopLoginTOKEN');
    window.vm.token = token;
    axios.post('https://127.0.0.1:44360/api/shop/getallproduct', { }, { }).then(function(response) {
        let data = response.data;
        window.vm.list = data;
    }).catch(function(error) {
        console.log(error);
    });

});