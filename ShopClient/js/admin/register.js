$(function() {
    window.vm = new Vue({
        el: '#app',
        data () {
            return {
                username: '',
                password: '',
                token: ''
            };
        },
        methods: {
            AddNewAdmin () {
                axios.post('https://127.0.0.1:44360/api/administrator/addnewadministrator', {
                    username: this.username,
                    password: this.password
                }, {
                    headers: {
                        token: this.token
                    }
                }).then(function(response) {
                    let data = response.data;

                }).catch(function(error) {
                    console.log(error);
                });
            }
        }
    });
    let token = window.localStorage.getItem('ShopAdminLoginTOKEN');
    window.vm.token = token;
});