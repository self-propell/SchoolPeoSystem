// 监听所有链接的点击事件
document.querySelectorAll('.sidebar-link').forEach(link => {
    link.addEventListener('click', function () {

        // 给当前点击的链接添加 'active' 类
        this.classList.add('active');
    });
});