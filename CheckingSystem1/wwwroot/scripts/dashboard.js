$(document).ready(function () {
    $.ajax({
        type: "post",
        url: 'Home/Dashboardcount',
        data: JSON.stringify({}),
        contentType: "application/json:chaset=utf-8",
        dataType: "json",
        success: function (json) {
            debugger
            var values = json.Dashboardcount;
            var softwarecount = parseInt(values[0]);
            var hardwarecount = parseInt(values[1]);
            var networkcount = parseInt(values[2]);
            var databasecount = parseInt(values[3]);


        }
    })

});



Highcharts.chart('container', {
    chart: {
        plotBackgroundColor: null,
        plotBorderWidth: null,
        plotShadow: false,
        type: 'pie'
    },
    title: {
        text: 'Browser market shares in January, 2018'
    },
    tooltip: {
        pointFormat: '{series.name}: <b>{point.percentage:.1f}%</b>'
    },
    accessibility: {
        point: {
            valueSuffix: '%'
        }
    },
    plotOptions: {
        pie: {
            allowPointSelect: true,
            cursor: 'pointer',
            dataLabels: {
                enabled: false
            },
            showInLegend: true
        }
    },
    series: [{
        name: 'Brands',
        colorByPoint: true,
        data: [{
            name: 'Chrome',
            y: 61.41,
            sliced: true,
            selected: true
        }, {
            name: 'Internet Explorer',
            y: 11.84
        }, {
            name: 'Firefox',
            y: 10.85
        }, {
            name: 'Edge',
            y: 4.67
        }, {
            name: 'Safari',
            y: 4.18
        }, {
            name: 'Other',
            y: 7.05
        }]
    }]
});