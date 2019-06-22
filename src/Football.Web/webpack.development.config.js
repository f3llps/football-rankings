const path = require('path');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: './js/index.js',
    output: {
        filename: 'bundle.js',
        path: path.resolve(__dirname, './dist'),
        publicPath: ''
    },
    mode: 'development',
    devServer:{
        contentBase: path.resolve(__dirname, './dist'),
        index: 'index.html',
        port: 9000
    },
    module: {
        rules: [
            {
                test: /\.js$/,
                exclude: /node_modues/,
                use: {
                    loader: 'babel-loader',
                    options: {
                        presets: ['@babel/env'], 
                        plugins: ['transform-class-properties']
                    }
                }
            },
            {
                test: /\.css$/,
                use: ['style-loader',  'css-loader']
            },
            {
                test: /\.scss$/,
                use: ['style-loader',   'css-loader', 'sass-loader']
            },
            {
                test: /\.scss$/,
                loader: 'sass-loader',
                options: {
                  "includePaths": [
                    path.resolve(__dirname, 'node_modules'),
                    path.resolve(__dirname, 'src')
                  ]
                }
            },
            {
                test: /\.hbs$/,
                use: ['handlebars-loader']
            }
        ]
    },
    plugins: [
        new CleanWebpackPlugin(),
        new HtmlWebpackPlugin({
            template: 'index.hbs',
            title:'Football API'
        }),
    ]
}   