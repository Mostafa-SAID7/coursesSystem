/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Views/**/*.cshtml',
    './Areas/**/Views/**/*.cshtml',
    './wwwroot/js/**/*.js'
  ],
  darkMode: 'class', // Enable dark mode via 'dark' class
  theme: {
    extend: {
      colors: {
        primary: '#4f46e5',   // Indigo
        secondary: '#f43f5e', // Pink
        background: {
          light: '#f9fafb',   // Light bg
          dark: '#1f2937'     // Dark bg
        },
        text: {
          light: '#1f2937',   // Dark text on light
          dark: '#f9fafb'     // Light text on dark
        }
      },
      fontFamily: {
        sans: ['Inter', 'ui-sans-serif', 'system-ui'],
      },
    },
  },
  plugins: [],
};