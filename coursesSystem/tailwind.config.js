/** @type {import('tailwindcss').Config} */
module.exports = {
  content: [
    './Views/**/*.cshtml',
    './Areas/**/Views/**/*.cshtml',
    './wwwroot/js/**/*.js'
  ],
  darkMode: 'class', // Enable dark mode via 'dark' class
  theme: {
    container: {
      center: true,
      padding: '2rem'
    },
    extend: {
      colors: {
        primary: '#4f46e5',   // Indigo
        secondary: '#f43f5e', // Pink
        background: {
          light: '#f9fafb',   // Light background
          dark: '#1f2937'     // Dark background
        },
        text: {
          light: '#1f2937',   // Dark text on light
          dark: '#f9fafb'     // Light text on dark
        },
        card: {
          light: '#ffffff',   // Card bg light
          dark: '#111827'     // Card bg dark
        },
        border: {
          light: '#e5e7eb',   // Light border
          dark: '#374151'     // Dark border
        }
      },
      fontFamily: {
        sans: ['Inter', 'ui-sans-serif', 'system-ui'],
      },
      boxShadow: {
        card: '0 4px 6px rgba(0,0,0,0.1)',
        cardDark: '0 4px 6px rgba(0,0,0,0.4)'
      },
      transitionProperty: {
        colors: 'color, background-color, border-color, text-decoration-color, fill, stroke'
      }
    },
  },
  plugins: [
    require('@tailwindcss/forms'),      // Styled forms (login/register)
    require('@tailwindcss/typography')   // Prose classes for course descriptions
  ],
};
