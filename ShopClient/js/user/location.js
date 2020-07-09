$(function() {
    window.vm = new Vue({
        el: '#app',
        data () {
            return {
                list: [],
                zipCode: '',
                name: '',
                token: ''
            };
        },
        methods: {
            addNewLocation () {
                axios.post('https://127.0.0.1:44360/api/location/addnewlocation', {
                    zipCode: this.zipCode,
                    name: this.name
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
                let delItem = this.list[index];
                axios.post('https://127.0.0.1:44360/api/location/removelocation', {
                    id: delItem.id,
                    zipCode: delItem.zipCode,
                    name: delItem.name
                }, {
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
        }
    });
    let token = window.localStorage.getItem('ShopLoginTOKEN');
    window.vm.token = token;
    axios.post('https://127.0.0.1:44360/api/location/getlocations', { }, {
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