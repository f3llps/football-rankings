const path = require('path');
const MiniCssExtractPlugin = require('mini-css-extract-plugin');
const CleanWebpackPlugin = require('clean-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');

module.exports = {
    entry: './js/index.js',
    output: {
        filename: 'bundle.[contenthash].js',
        path: path.resolve(__dirname, './dist'),
        publicPath: ''
    },
    mode: 'production',
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
                use: [MiniCssExtractPlugin.loader,  'css-loader']
            },
            {
                test: /\.scss$/,
                use: [MiniCssExtractPlugin.loader,   'css-loader', 'sass-loader']
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
        new MiniCssExtractPlugin({
            filename: 'styles.[contenthash].css'
        }),
        new CleanWebpackPlugin(),
        new HtmlWebpackPlugin({
            template: 'index.hbs',
            title:'Football API'
        }),
    ]
}   