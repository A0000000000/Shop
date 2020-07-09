$(function() {
    window.vm = new Vue({
        el: "#app",
        data () {
            return {
                username: '',
                password: '',
                email: '',
                phone: '',
                birthday: null
            };
        },
        methods: {
            register() {
                axios.post('https://127.0.0.1:44360/api/customer/register', {
                    username: this.username,
                    password: this.password,
                    email: this.email,
                    phone: this.phone,
                    birthday: this.birthday
                }).then(function(response) {
                    let data = response.data;
                    if (data.status === 'success') {
                        alert('注册成功!');
                        location.href = '/view/user/login.html';
                    } else {
                        alert(data.message);
                    }
                }).catch(function(error) {
                    console.log(error);
                });
                
            }
        }
    });
});