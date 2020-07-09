$(function(){
    window.vm = new Vue({
        el: '#app',
        data () {
            return {
                username: '',
                password: ''    
            };
        },
        methods: {
            login() {
                axios.post('https://127.0.0.1:44360/api/customer/login', {
                    username: this.username,
                    password: this.password
                }).then(function(response) {
                    let data = response.data;
                    if (data.status === 'failed') {
                        alert(data.message);
                    } else {
                        window.localStorage.setItem('ShopLoginTOKEN', data.token);
                        location.href = '/view/user/info.html';
                    }
                }).catch(function(error) {
                    console.log(error);
                });
            }
        }
    });
});